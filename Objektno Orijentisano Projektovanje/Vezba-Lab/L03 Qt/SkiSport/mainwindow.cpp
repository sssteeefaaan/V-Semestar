#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    if(ui)
    {
        delete ui;
        ui = 0;
    }
}

void MainWindow::closeEvent(QCloseEvent *event)
{
    event->accept();
}
