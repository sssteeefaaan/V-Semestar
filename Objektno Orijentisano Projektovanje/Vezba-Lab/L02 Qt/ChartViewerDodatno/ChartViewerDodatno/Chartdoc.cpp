#include "Chartdoc.h"

ChartDoc::ChartDoc(QObject *parent) : QObject(parent)
{
    m_mod = false;
    m_filePath = "";
}

ChartDoc::~ChartDoc()
{ clear(); }

bool ChartDoc::loadChartFromFile(QString file)
{
    clear();    // S obzirom da učitavamo novi podatak, potrebno je da obrišemo stare

    QFile f(file);  // setujemo f na prosleđeni file(Path)
    if(f.open(QFile::ReadOnly | QFile::Text))
    {
        // Najlakše mi je bilo sa TextStream-om da radim, tako da njega inicijalizujemo
        QTextStream stream(&f);
        // Čitamo liniju po liniju
        QString line = stream.readLine();
        while(line!="KRAJ") // Dok ne dođemo do kraja, koji nam predstavlja neki dogovar da se fajl tako završava
        {
            // delim liniju koju sam pročitao na deo pre taba sepT[0] i deo nakon taba sepT[1]
            QStringList sepT = line.split("\t");
            // Deo nakon taba delim da tri dela sepC[0] (sadrži labelu), sepC[1] (sadrži vrednost), sepC[2] (sadrži hex code za boju)
            QStringList sepC = sepT[1].split(",");
            // Kreiram novi ChartPoint sa prosleđenim podacima iz fajla, koje konvertujem u odgovarajuće objekte
            m_points.append(new ChartPoint(sepC[0],sepC[1].toFloat(),QColor(sepC[2])));
            // Čitam sledeću liniju
            line = stream.readLine();
        }
        f.close();

        // S obzirom da smo pročitali ispravan filePath, upisujemo ga u promenljuvu koja skladišti
        m_filePath = file;
        // Nemamo promene, jer smo upravo pročitali
        m_mod = false;
        // Pročitali smo, a sad emitujemo signal koji obaveštava da je neophodno ponovo da se iscrta
        emit chartDataChanged();
        return true;
    }
    return false;
}

bool ChartDoc::saveChartToFile()
{
    // setovanje f na odgovarajući (zapamćeni filePath)
    QFile f(m_filePath);
    if(f.open(QFile::WriteOnly | QFile::Text))
    {
        QTextStream stream(&f);
        // Deklarišem string, koji ću koristiti za upisivanje u textStream
        QString cont;
        for(int i = 0; i < m_points.size(); i++)
        {
           // Ovaj deo je generic, tako da petlja sama može da ga ispiše
           cont = "label" + QString::number(i);
           cont += ",value" + QString::number(i);
           cont += ",color" + QString::number(i) + "\t";
           // Ovo su podaci i to prosleđujem savePoint funckiji, sa stringom u koji će upisati te podatke
           m_points[i]->savePoint(cont);
           // Sadržaj i-te linije upisujem u text stream
           stream << cont + "\n";
        }
        // Ovo predstavlja kraj fajla, moglo je i bez njega, ali bi onda bila potrbna izmena i loadChartFromFIle funkcije
        stream << "KRAJ";

        f.close();
        // Sačuvali smo podatke, tako da možemo setovati modifikaciju na false
        m_mod = false;
        return true;
    }
    return false;
}

void ChartDoc::clear()
{
    // Obrisaće objekte u dinamičkoj memoriji
    foreach(ChartPoint* p, m_points)
    {
        if(p)
            delete p;
        p = NULL;
    }
    // Isprazniti listu
    m_points.clear();
    m_mod = false;
    m_filePath = "";
}

// Iscrtavanje osa i podataka
void ChartDoc::draw(QPainter &p, int width, int height)
{
    // Setovanje olovke i fonta
    QPen pen(Qt::black, 3, Qt::SolidLine, Qt::SquareCap, Qt::BevelJoin);
    QFont font;
    font.setPixelSize(16);
    font.setBold(true);

    // Izabrao sam da crtež bude responsive, što znači da promenom veličine prozora, program "sam" određuje koje će biti dimenzije chart-a
    // propY mi predstavlja visinu jednog podeoka na Y osi
    // Pretpostavka je da su podaci dati u procentima 0-100, dakle ukoliko uzmem korak 10, imaću 10 podeoka, sa visinom propY
    // height je visina widget-a na kom se crta, a oduzimam 40, jer sam izabrao da margine budu po 20px levo i desno
    int propY = (height - 40)/10;

    // Ukoliko imamo podatke
    if(m_points.size() > 0)
    {
        // Računam širinu jednog chart-a, uključujući sa razmakom (širina je propX - 10, a razmak 10)
        // Delim sa brojem chart-ova u listi
        int propX = (width - 60)/m_points.size();
        for(int i = 0; i < m_points.size(); i++)
        {
            // Iscrtavam jedan chart
            drawSingleBarChart(p, propX, propY, i);
            // Ispisujem labelu i-og chart-a
            p.setPen(pen);
            p.setFont(font);
            p.drawText(i*propX + (m_points[i]->getColor().name().length() + propX + 30)/2, propY*10 + 40, m_points[i]->getLabel());
        }
    }
    else
    {
        p.setPen(pen);
        p.setFont(font);
    }

    // Iscrtavanje vertikalne ose
    p.drawLine(QLine(50, 20, 50, propY*10 + 20));

    // Iscrtavanje podeoka
    for(int i = 0; i <= 10; i++)
    {
        // Ispisujem tekst i s obzirom da se ispisivanje vrži nadole, vrednosti idu od 100 do '
        p.drawText(10, propY*i + 30, QString::number((10-i)*10));

        // Ukoliko nije reč o poslednjoj (x osi)
        if(i!=10)
            // Iscrtavam samo podeoke (crte dužine 10, 5px levo i px desno od vertikalne ose
            p.drawLine(QLine(45, propY*i + 20, 55, propY*i + 20));
        else
            // Iscrtavam x osu, koja je od leve strane prozora 50px (zbog teksta), a od desno 10px
            p.drawLine(QLine(50, propY*i + 20, width - 10, propY*i + 20));
    }

}

// Iscrtavanje jednog chart-a
void ChartDoc::drawSingleBarChart(QPainter& p, int propX, int propY, int pos)
{
    // Ovo je normalizacija vrednosti value [0-100] transformišem u opseg [a-b] (a jeste veće od b, ali je to zbog smera y ose)
    // gde su mi a = propY*10 + 20, b = 20, x_min = 0, x_max = 100
    // X_norm (x) = (b - a) * (x - x_min)/(x_max - x_min) + a
    float valNorm = (20 - (propY*10 + 20))*m_points[pos]->getValue()/100 + propY*10 + 20;

    // Setovanje olovke (nije neophodno, jer je u roditeljskoj funkciji već podešeno, ali da bih ispoštovao kako je definisana funkcija
    QPen penO(Qt::black, propX - 10, Qt::SolidLine, Qt::FlatCap, Qt::BevelJoin);
    QPen penI(m_points[pos]->getColor(), propX - 12, Qt::SolidLine, Qt::FlatCap, Qt::BevelJoin);

    // Iscrtavanje pravougaonika
    p.setPen(penO);
    p.drawLine(pos*propX + (propX + 90)/2, valNorm, pos*propX + (propX + 90)/2, propY*10 + 19);

    p.setPen(penI);
    p.drawLine(pos*propX + (propX + 90)/2, valNorm + 1, pos*propX + (propX + 90)/2, propY*10 + 20);
    //p.drawRoundedRect(pos*propX + 50, valNorm, propX - 10, propY*10 + 20 - valNorm, 0, 15);       // y = x^2 - 25*x + 150 = 0 x1=10, x2=15
}

// Funkcija koja dodaje novi pointer u listu i emituje da je došlo do izmene podataka
void ChartDoc::addNew(ChartPoint *p)
{
    m_points.append(p);
    emit chartDataChanged();
}

// Geter i seter za filePath i mod
QString ChartDoc::filePath()
{ return m_filePath; }

void ChartDoc::setFilePath(QString path)
{ m_filePath = path; }

bool ChartDoc::isMod()
{ return m_mod; }

void ChartDoc::setMod(bool b)
{ m_mod = b; }

// Funckija koj pronalazi da li se QPoint nalazi u nekom od iscrtanih chart-ova (pravougaonika)
bool ChartDoc::select(QPoint point, int width /* širina prostora na kome se crta */, int height /* visina prostora na kome se crta */)
{
    if(m_points.size()){
        // Već objašnejno gore
        int propX = (width - 60)/m_points.size();
        int propY = (height - 40)/10;
        for(int i = 0; i < m_points.size(); i++)
        {
            float valNorm = (20 - (propY*10 + 20))*m_points[i]->getValue()/100 + propY*10 + 20;
            if((point.x() >= i*propX + 50 && point.x() <= (i+1)*propX + 40) && (point.y() >= valNorm && point.y() <= propY*10 + 20))
            {
                // Ukoliko se ispostavi da je point u i-om pravougaoniku emituje se signal, koji prosleđuje pokazivač na taj chatPoint
                emit selected(m_points[i]);
                return true;
            }

        }
    }
    return false;
}
