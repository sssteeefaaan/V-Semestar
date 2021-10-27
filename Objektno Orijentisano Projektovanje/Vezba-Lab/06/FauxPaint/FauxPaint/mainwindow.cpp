#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QMessageBox>
#include <QFileDialog>
#include <QColorDialog>
#include <QInputDialog>
#include <QTimer>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    updateButtons();
}

MainWindow::~MainWindow()
{
    delete ui;
}

bool MainWindow::askToSave()
{
    if(ui->centralwidget->doc.isModified())
    {
        int res = QMessageBox::warning(this, windowTitle(), "Current document is modified.\nDo you want to save the changes?", "Yes", "No", "Cancel");
        if(res == 0)
        {
            on_actionSave_triggered();
            return true;
        }
        else if(res == 2)
            return false;
    }
    return true;
}
void MainWindow::on_actionNew_triggered()
{
    if(!askToSave()) return;

    ui->centralwidget->doc.clear();
    ui->centralwidget->repaint();
}

void MainWindow::on_actionOpen_triggered()
{
    if(!askToSave()) return;

    QString filePath = QFileDialog::getOpenFileName(this, /*filename*/"", QDir::currentPath(), "CurveDraw Document (*.cdd);;All Files (*.*)");
    if(!filePath.isEmpty())
    {
        ui->centralwidget->doc.clear();
        if(!ui->centralwidget->doc.load(filePath))
            QMessageBox::warning(this, windowTitle(), "Error opening the document!", "Ok");
    }
    ui->centralwidget->repaint();
}

void MainWindow::on_actionSave_triggered()
{
    if(ui->centralwidget->doc.filePath().isEmpty())
        on_actionSave_As_triggered();
    else
        if(!ui->centralwidget->doc.save())
            QMessageBox::warning(this, windowTitle(), "Error saving the document!", "Ok");
}

void MainWindow::on_actionSave_As_triggered()
{
    QString filePath = QFileDialog::getSaveFileName(this, /*fileName*/"", QDir::currentPath(), "CurveDraw Document (*.cdd);;All Files (*.*)");
    if(!filePath.isEmpty())
    {
        ui->centralwidget->doc.setFilePath(filePath);
        on_actionSave_triggered();
    }
}

void MainWindow::on_actionExit_triggered()
{
    emit close();
}

void MainWindow::on_action1px_triggered()
{
    ui->centralwidget->width = 1;
    updateButtons();
}

void MainWindow::on_action2px_triggered()
{
    ui->centralwidget->width = 2;
    updateButtons();
}

void MainWindow::on_action5px_triggered()
{
    ui->centralwidget->width = 5;
    updateButtons();
}

void MainWindow::on_action10px_triggered()
{
    ui->centralwidget->width = 10;
    updateButtons();
}

void MainWindow::on_actionBlack_triggered()
{
    ui->centralwidget->color = qRgba(0, 0, 0, 128);
    updateButtons();
}

void MainWindow::on_actionWhite_triggered()
{
    ui->centralwidget->color = qRgba(255, 255, 255, 128);
    updateButtons();
}

void MainWindow::on_actionRed_triggered()
{
    ui->centralwidget->color = qRgba(255, 0, 0, 128);
    updateButtons();
}

void MainWindow::on_actionBlue_triggered()
{
    ui->centralwidget->color = qRgba(0, 0, 255, 128);
    updateButtons();
}

void MainWindow::on_actionGreen_triggered()
{
    ui->centralwidget->color = qRgba(0, 255, 0, 128);
    updateButtons();
}

void MainWindow::on_actionMore_Colors_triggered()
{
    QColor col = QColorDialog::getColor(Qt::white,this,"Select Color");
    ui->centralwidget->color = qRgba(col.red(),col.green(),col.blue(),col.alpha());
    updateButtons();
}

void MainWindow::on_actionMore_Sizes_triggered()
{
    QInputDialog id(this);
    ui->centralwidget->width = (quint8)QInputDialog::getInt(this,"Input value","Width: ");
    updateButtons();
}

void MainWindow::updateButtons()
{
    ui->action1px->setChecked(ui->centralwidget->width == 1);
    ui->action2px->setChecked(ui->centralwidget->width == 2);
    ui->action5px->setChecked(ui->centralwidget->width == 5);
    ui->action10px->setChecked(ui->centralwidget->width == 10);

    ui->actionBlack->setChecked(ui->centralwidget->color == qRgba(0, 0, 0, 128));
    ui->actionWhite->setChecked(ui->centralwidget->color == qRgba(255, 255, 255, 128));
    ui->actionRed->setChecked(ui->centralwidget->color == qRgba(255, 0, 0, 128));
    ui->actionBlue->setChecked(ui->centralwidget->color == qRgba(0, 0, 255, 128));
    ui->actionGreen->setChecked(ui->centralwidget->color == qRgba(0, 255, 0, 128));
}

void MainWindow::closeEvent(QCloseEvent* e)
{
    if(!askToSave())
        e->ignore();
    else
        e->accept();
}

void MainWindow::on_actionRainbow_triggered() // Ne radi
{
    QTimer *timer = new QTimer(this);
    timer->setInterval(1000);
    connect(timer, SIGNAL(timeout()), this, SLOT(colorInc()));
    timer->start();
}

void MainWindow::colorInc()
{
    int r = ui->centralwidget->color.red(), g = ui->centralwidget->color.green(), b = ui->centralwidget->color.blue();
    ui->centralwidget->color = qRgba((r+1)%256, (g+1)%256, (b+1)%256, 128);
}
