#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    // Povezivanje signala i slotova
    connect(ui->centralwidget->getDoc(), SIGNAL(chartDataChanged()), this->centralWidget(), SLOT(onChartDataChanged()));
    connect(ui->centralwidget->getDoc(), SIGNAL(selected(ChartPoint*)), this, SLOT(selected(ChartPoint*)));
}

MainWindow::~MainWindow()
{ delete ui; }

void MainWindow::closeEvent(QCloseEvent* e){
    if(!askToSave())    // Ukoliko funckija vrati true (Korisnik je izabrao da sačuva fajl) i ostaje se u programu
        e->ignore();    // U suprotnom se prihvata zatvaranje
    else
        e->accept();
}

// Ubacivanje chart-a direktno u program
void MainWindow::on_actionInsert_triggered()
{
    // Incijalizujemo ChartPointDialog
    ChartPointDialog d(this);
    d.setWindowTitle("Input");
    // Ukoliko je korisnik uneo podatke i pritisnuo Ok
    if(d.exec() == QDialog::Accepted)
    {
        QString lab;
        float val;
        QColor col;
        // Čitamo podatke
        d.getContent(lab, val, col);

        // Dodajemo u listu chart-ova
        ui->centralwidget->getDoc()->addNew(new ChartPoint(lab, val, col));
    }
}

void MainWindow::selected(ChartPoint *p)
{
    // Ukoliko je izabran odgovarajuči čart otvaramo "njegov" dijalog
    ChartPointDialog d(this);
    d.setContent(p);
    d.setWindowTitle("Select");
    // Ukoliko se prihvate podaci
    if(d.exec() == QDialog::Accepted)
    {
        QString lab;
        float val;
        QColor col;
        // Čitamo ih
        d.getContent(lab, val, col);

        // Menjamo ih za dati chartPoint i emitujemo signal da se chartDoc promenio
        p->setPoint(lab, val, col);
        emit ui->centralwidget->getDoc()->chartDataChanged();
    }
}

void MainWindow::on_action_Load_Chart_triggered()
{
    // Prvo prompt-ujemo da li korisnik želi da sačuva svoje izmene
    askToSave();
    // Standradno nalaženje datoteke i čitanje
    QString filePath = QFileDialog::getOpenFileName(this, "", QDir::currentPath(), "Text File (*.txt);;All Files (*.*)");
    if(!filePath.isEmpty())
        if(!ui->centralwidget->getDoc()->loadChartFromFile(filePath))
            QMessageBox::warning(this, windowTitle(), "Error opening the document!", "Ok");
    ui->centralwidget->repaint();
}

bool MainWindow::askToSave()
{
    if(ui->centralwidget->getDoc()->isMod()) // Ukoliko je modifikovano u međuvremenu
    {
        // Izbacuje MessageBox koji pita da li želimo da sačuvamo izmene
        int res = QMessageBox::warning(this, windowTitle(), "Current document is modified.\nDo you want to save the changes?", "Yes", "No", "Cancel");
        if(res == 0)
        {
            // Ukoliko želimo, idemo u čuvanje
            on_action_Save_Chart_triggered();
            return true;
        }
        // U suprotnom vraćamo false
        else if(res == 2)
            return false;
    }
    return true;
}

// Standardno čuvanje u odgovarajući filePath
void MainWindow::on_action_Save_Chart_triggered()
{
    if(ui->centralwidget->getDoc()->filePath().isEmpty())
        on_actionSave_As_triggered();
    else
        if(!ui->centralwidget->getDoc()->saveChartToFile())
            QMessageBox::warning(this, windowTitle(), "Error saving the document!", "Ok");
}

void MainWindow::on_actionSave_As_triggered()
{
    // Ne znamo filePath, pa ga ovim korisnik unosi
    QString filePath = QFileDialog::getSaveFileName(this, "", QDir::currentPath(), "Text (*.txt);;All Files (*.*)");
    //Ukoliko je ispravan
    if(!filePath.isEmpty())
    {
        // Setujemo ga u ChartDoc i pozivamo Save
        ui->centralwidget->getDoc()->setFilePath(filePath);
        on_action_Save_Chart_triggered();
    }
}
