#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QMessageBox>
#include <QFileDialog>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
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
    if(ui->centralWidget->doc.isModified())
    {
        int res = QMessageBox::warning(this, windowTitle(), "Current document is modified.\nDo you want to save the changes?", "Yes", "No", "Cancel");
        if(res == 0)
        {
            on_action_Save_triggered();
            return true;
        }
        else if(res == 2)
        {
            return false;
        }
    }

    return true;
}

void MainWindow::on_action_New_triggered()
{
    if(!askToSave()) return;

    ui->centralWidget->doc.clear();

    ui->centralWidget->repaint();
}

void MainWindow::on_action_Open_triggered()
{
    if(!askToSave()) return;

    QString filePath = QFileDialog::getOpenFileName(this, QString(), QString(), "CurveDraw Document (*.cdd);;All Files (*.*)");
    if(!filePath.isEmpty())
    {
        ui->centralWidget->doc.clear();
        if(!ui->centralWidget->doc.load(filePath))
        {
            QMessageBox::warning(this, windowTitle(), "Error opening the document!", "Ok");
        }

        ui->centralWidget->repaint();
    }
}

void MainWindow::on_action_Save_triggered()
{
    if(ui->centralWidget->doc.filePath().isEmpty())
    {
        on_actionSave_As_triggered();
    }
    else
    {
        if(!ui->centralWidget->doc.save())
        {
            QMessageBox::warning(this, windowTitle(), "Error saving the document!", "Ok");
        }
    }
}

void MainWindow::on_actionSave_As_triggered()
{
    QString filePath = QFileDialog::getSaveFileName(this, QString(), QString(), "CurveDraw Document (*.cdd);;All Files (*.*)");
    if(!filePath.isEmpty())
    {
        ui->centralWidget->doc.setFilePath(filePath);
        on_action_Save_triggered();
    }
}

void MainWindow::on_actionE_xit_triggered()
{
    emit close();
}

void MainWindow::on_action_1_triggered()
{
	ui->centralWidget->width = 1;
	updateButtons();
}

void MainWindow::on_action_3_triggered()
{
	ui->centralWidget->width = 3;
	updateButtons();
}

void MainWindow::on_action_5_triggered()
{
	ui->centralWidget->width = 5;
	updateButtons();
}

void MainWindow::on_action_10_triggered()
{
	ui->centralWidget->width = 10;
	updateButtons();
}

void MainWindow::on_action_Black_triggered()
{
	ui->centralWidget->color = qRgba(0, 0, 0, 128);
	updateButtons();
}

void MainWindow::on_action_Red_triggered()
{
	ui->centralWidget->color = qRgba(255, 0, 0, 128);
	updateButtons();
}

void MainWindow::on_action_Green_triggered()
{
	ui->centralWidget->color = qRgba(0, 255, 0, 128);
	updateButtons();
}

void MainWindow::on_action_Blue_triggered()
{
	ui->centralWidget->color = qRgba(0, 0, 255, 128);
	updateButtons();
}

void MainWindow::updateButtons()
{
	ui->action_1->setChecked(ui->centralWidget->width == 1);
	ui->action_3->setChecked(ui->centralWidget->width == 3);
	ui->action_5->setChecked(ui->centralWidget->width == 5);
	ui->action_10->setChecked(ui->centralWidget->width == 10);

	ui->action_Black->setChecked(ui->centralWidget->color == qRgba(0, 0, 0, 128));
	ui->action_Red->setChecked(ui->centralWidget->color == qRgba(255, 0, 0, 128));
	ui->action_Green->setChecked(ui->centralWidget->color == qRgba(0, 255, 0, 128));
	ui->action_Blue->setChecked(ui->centralWidget->color == qRgba(0, 0, 255, 128));
}

void MainWindow::closeEvent(QCloseEvent* e)
{
	if(!askToSave())
	{
		e->ignore();
	}
	else
	{
		e->accept();
	}
}
