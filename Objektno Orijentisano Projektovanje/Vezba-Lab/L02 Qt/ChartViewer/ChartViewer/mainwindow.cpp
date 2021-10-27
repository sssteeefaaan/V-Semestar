#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    connect(ui->centralwidget->m_chartDoc, SIGNAL(chartDataChanged()), this->centralWidget(), SLOT(onChartDataChanged()));
    connect(ui->centralwidget->m_chartDoc, SIGNAL(selected(ChartPoint*)), this, SLOT(selected(ChartPoint*)));
}

MainWindow::~MainWindow()
{ delete ui; }

void MainWindow::closeEvent(QCloseEvent* e){
    if(!askToSave())
            e->ignore();
    else {
        e->accept();
    }
}

void MainWindow::on_actionInsert_triggered()
{
    ChartPointDialog d(this);
    d.setWindowTitle("Input");
    if(d.exec() == QDialog::Accepted)
    {
        QString lab;
        float val;
        QColor col;
        d.getContent(lab, val, col);

        ui->centralwidget->m_chartDoc->addNew(new ChartPoint(lab, val, col));
    }
}

void MainWindow::selected(ChartPoint *p)
{
    ChartPointDialog d(this);
    d.setContent(p);
    d.setWindowTitle("Select");
    if(d.exec() == QDialog::Accepted)
    {
        QString lab;
        float val;
        QColor col;
        d.getContent(lab, val, col);

        p->setPoint(lab, val, col);
        emit ui->centralwidget->m_chartDoc->chartDataChanged();
    }
}

void MainWindow::on_action_Load_Chart_triggered()
{
    askToSave();
    QString filePath = QFileDialog::getOpenFileName(this, "", QDir::currentPath(), "Chart (*.txt);;All Files (*.*)");
    if(!filePath.isEmpty())
        if(!ui->centralwidget->m_chartDoc->loadChartFromFile(filePath))
            QMessageBox::warning(this, windowTitle(), "Error opening the document!", "Ok");
    ui->centralwidget->repaint();
}

bool MainWindow::askToSave()
{
    if(ui->centralwidget->m_chartDoc->isMod())
    {
        int res = QMessageBox::warning(this, windowTitle(), "Current document is modified.\nDo you want to save the changes?", "Yes", "No", "Cancel");
        if(res == 0)
        {
            on_action_Save_Chart_triggered();
            return true;
        }
        else if(res == 2)
            return false;
    }
    return true;
}

void MainWindow::on_action_Save_Chart_triggered()
{
    if(ui->centralwidget->m_chartDoc->filePath().isEmpty())
        on_actionSave_As_triggered();
    else
        if(!ui->centralwidget->m_chartDoc->saveChartToFile())
            QMessageBox::warning(this, windowTitle(), "Error saving the document!", "Ok");
}

void MainWindow::on_actionSave_As_triggered()
{
    QString filePath = QFileDialog::getSaveFileName(this, "", QDir::currentPath(), "Text (*.txt);;All Files (*.*)");
    if(!filePath.isEmpty())
    {
        ui->centralwidget->m_chartDoc->setFilePath(filePath);
        on_action_Save_Chart_triggered();
    }
}
