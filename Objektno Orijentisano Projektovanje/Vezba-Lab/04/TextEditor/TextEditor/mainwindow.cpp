#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QMessageBox>
#include <QFile>
#include <QFileDialog>
#include <QTimer>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , settings(new QSettings(QSettings::UserScope,"Stefan Aleksic", "Plain Text Editor", this))
{
    ui->setupUi(this);

    changed = false;

    ui->listWidget->addItem(QString("and"));
    ui->listWidget->addItem(QString("or"));
    ui->listWidget->addItem(QString("not"));
    ui->listWidget->addItem(QString("if"));
    ui->listWidget->addItem(QString("else"));

    QTimer::singleShot(0, this, SLOT(updatePasteAction()));

    if(settings->contains("geometry"))
        this->restoreGeometry(settings->value("geometry").toByteArray());

    if(settings->contains("windowState"))
        this->restoreState(settings->value("windowState").toByteArray());
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::closeEvent(QCloseEvent* e){
    wannaSave();
    settings->setValue("geometry",saveGeometry());
    settings->setValue("windowState", saveState());
    QMainWindow::closeEvent(e);
}

void MainWindow::wannaSave()
{
    if(changed && ui->plainTextEdit->toPlainText()!="") // idk
    {
        int res = QMessageBox::question(this,this->windowTitle(),"The document is modified.\nDo you want to save changes, BITCH?", QMessageBox::Yes, QMessageBox::No, QMessageBox::Cancel);
        if(res==QMessageBox::Cancel)
            return;
        if(res == QMessageBox::Yes)
            on_actionSave_triggered();
    }
}


void MainWindow::on_plainTextEdit_copyAvailable(bool b)
{
    ui->actionCopy->setEnabled(b);
}
void MainWindow::on_plainTextEdit_cutAvailable(bool b)
{
    ui->actionCut->setEnabled(b);
}
void MainWindow::updatePasteAction()
{
    ui->actionPaste->setEnabled(ui->plainTextEdit->canPaste());
    QTimer::singleShot(500, this, SLOT(updatePasteAction()));
}


void MainWindow::on_plainTextEdit_undoAvailable(bool b)
{
    ui->actionUndo->setEnabled(b);
}
void MainWindow::on_plainTextEdit_redoAvailable(bool b)
{
    ui->actionRedo->setEnabled(b);
}

void MainWindow::on_plainTextEdit_textChanged()
{
    changed = true;
    if(ui->plainTextEdit->toPlainText().contains("Luka"))
    {
        QString temp = ui->plainTextEdit->toPlainText();
        temp.replace("Luka","Lep dečko",Qt::CaseSensitive);
        ui->plainTextEdit->setPlainText(temp);
    }
}

void MainWindow::on_actionNew_triggered()
{
    wannaSave();

    ui->plainTextEdit->clear();
    fileName.clear();
    changed=false;
}

void MainWindow::on_actionOpen_triggered()
{
    wannaSave();

    QString fname = QFileDialog::getOpenFileName(this, this->windowTitle(), QDir::currentPath(), "Text Files (*.txt);;All Files (*.*)");
    if(!fname.isEmpty())
    {
        QFile f(fname);
        if(f.open(QFile::ReadOnly | QFile::Text))
        {
            QByteArray buff = f.readAll();
            ui->plainTextEdit->setPlainText(QString::fromUtf8(buff.data(), buff.size()));
            f.close();

            fileName = fname;
            changed = false;
        }
        else
            QMessageBox::critical(this, this->windowTitle(), "Error opening file:\n" + fname, QMessageBox::Ok);
    }
}

void MainWindow::on_actionSave_triggered()
{
    if(fileName.isEmpty())
        on_actionSave_As_triggered();
    else
    {
        QFile f(fileName, this);
        if(f.open(QFile::WriteOnly | QFile::Text))
        {
            QString text = ui->plainTextEdit->toPlainText();
            f.write(text.toUtf8());
            f.close();
            changed = false;
        }
        else
            QMessageBox::critical(this, this->windowTitle(), "Error opening file:\n" + fileName, QMessageBox::Ok);
    }
}

void MainWindow::on_actionSave_As_triggered()
{
    QString fname = QFileDialog::getSaveFileName(this, this->windowTitle(), QDir::currentPath(), "Text Files (*.txt);;All Files(*.*)");
    if(!fname.isEmpty())
    {
        QFile f(fname);
        if(f.open(QFile::WriteOnly | QFile::Text))
        {
            QString text = ui->plainTextEdit->toPlainText();
            f.write(text.toUtf8());
            f.close();

            fileName = fname;
            changed = false;
        }
        else
        {
            QString msg = "Error opening file:\n" + fname;
            QMessageBox::critical(this, this->windowTitle(), msg, QMessageBox::Ok);
        }
    }
}

void MainWindow::on_listWidget_doubleClicked(const QModelIndex &index)
{
    QListWidgetItem* item = ui->listWidget->item(index.row());
    if(item)
        ui->plainTextEdit->textCursor().insertText(item->text());
}
