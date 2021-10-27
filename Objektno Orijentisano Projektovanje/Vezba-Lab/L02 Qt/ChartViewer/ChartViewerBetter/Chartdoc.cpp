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
    clear();

    QFile f(file);
    if(f.open(QFile::ReadOnly | QFile::Text))
    {
        QTextStream stream(&f);
        QString line = stream.readLine();
        while(line!="KRAJ")
        {
            QStringList sepT = line.split("\t");
            QStringList sepC = sepT[1].split(",");
            m_points.append(new ChartPoint(sepC[0],sepC[1].toFloat(),QColor(sepC[2])));
            line = stream.readLine();
        }
        f.close();

        m_filePath = file;
        m_mod = false;
        emit chartDataChanged();
        return true;
    }
    return false;
}

bool ChartDoc::saveChartToFile()
{
    QFile f(m_filePath);
    if(f.open(QFile::WriteOnly | QFile::Text))
    {
        QTextStream stream(&f);
        QString cont;
        for(int i = 0; i < m_points.size(); i++)
        {
           cont = "label" + QString::number(i);
           cont += ",value" + QString::number(i);
           cont += ",color" + QString::number(i) + "\t";
           m_points[i]->savePoint(cont);
           stream << cont + "\n";
        }
        stream << "KRAJ";

        f.close();
        m_mod = false;
        return true;
    }
    return false;
}

void ChartDoc::clear()
{
    foreach(ChartPoint* p, m_points)
    {
        if(p)
            delete p;
        p = NULL;
    }
    m_points.clear();
    m_mod = false;
    m_filePath = "";
}

void ChartDoc::draw(QPainter &p, int width, int height)
{
    QPen pen(Qt::black, 3, Qt::SolidLine, Qt::SquareCap, Qt::BevelJoin);
    QFont font;
    font.setPixelSize(16);
    font.setBold(true);

    p.setPen(pen);
    p.setFont(font);

    int propY = (height - 40)/10;

    p.drawLine(QLine(50, 20, 50, propY*10 + 20));

    for(int i = 0; i <= 10; i++)
    {
        p.drawText(10, propY*i + 30, QString::number((10-i)*10));
        if(i!=10)
            p.drawLine(QLine(45, propY*i + 20, 55, propY*i + 20));
        else
            p.drawLine(QLine(50, propY*i + 20, width - 10, propY*i + 20));
    }

    if(m_points.size())
    {
        int propX = (width - 60)/m_points.size();
        for(int i = 0; i < m_points.size(); i++)
        {
            float valNorm = (20 - (propY*10 + 20))*m_points[i]->getValue()/100 + propY*10 + 20;
            p.setBrush(QBrush(m_points[i]->getColor(),Qt::BrushStyle::SolidPattern));
            p.drawRect(QRect(i*propX + 50, valNorm, propX - 10, propY*10 + 20 - valNorm));
            p.drawText(i*propX + (40 + m_points[i]->getColor().name().length() + propX)/2, propY*10 + 40, m_points[i]->getLabel());
        }
    }
}

void ChartDoc::addNew(ChartPoint *p)
{
    m_points.append(p);
    emit chartDataChanged();
}

QString ChartDoc::filePath()
{ return m_filePath; }

void ChartDoc::setFilePath(QString path)
{ m_filePath = path; }

bool ChartDoc::isMod()
{ return m_mod; }

void ChartDoc::setMod(bool b)
{ m_mod = b; }

bool ChartDoc::select(QPoint point, int width, int height)
{
    if(m_points.size()){
        int propX = (width - 60)/m_points.size();
        int propY = (height - 40)/10;
        for(int i = 0; i < m_points.size(); i++)
        {
            float valNorm = (20 - (propY*10 + 20))*m_points[i]->getValue()/100 + propY*10 + 20;
            if((point.x() >= i*propX + 50 && point.x() <= (i+1)*propX + 40) && (point.y() >= valNorm && point.y() <= propY*10 + 20))
            {
                emit selected(m_points[i]);
                return true;
            }

        }
    }
    return false;
}
