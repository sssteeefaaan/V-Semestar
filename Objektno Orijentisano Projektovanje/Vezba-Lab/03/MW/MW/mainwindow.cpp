#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "searchdialog.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_actionSearch_triggered()
{
    SearchDialog dlg;

    if(dlg.exec()==QDialog::Accepted){

        QMessageBox::information(this,"WUHU",dlg.getSrchWord());
    }
}
