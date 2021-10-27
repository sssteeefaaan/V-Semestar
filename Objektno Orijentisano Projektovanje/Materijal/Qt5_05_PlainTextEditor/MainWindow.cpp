#include "MainWindow.h"
#include "ui_MainWindow.h"
#include <QMessageBox>
#include <QFile>
#include <QFileDialog>
#include <QTimer>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
	ui(new Ui::MainWindow),
	settings(new QSettings(QSettings::UserScope, "Aleksandar Milosavljevic", "Plain Text Editor", this))
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
	{
		this->restoreGeometry(settings->value("geometry").toByteArray());
	}
	if(settings->contains("windowState"))
	{
		this->restoreState(settings->value("windowState").toByteArray());
	}
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::closeEvent(QCloseEvent* e)
{
	if(changed)
	{
		int res = QMessageBox::question(this, this->windowTitle(), "The document is modified.\nDo you want to save changes?", QMessageBox::Yes, QMessageBox::No, QMessageBox::Cancel);
		if(res == QMessageBox::Cancel)
		{
			return;
		}
		if(res == QMessageBox::Yes)
		{
			on_action_Save_triggered();
		}
	}
	settings->setValue("geometry", saveGeometry());
	settings->setValue("windowState", saveState());
	QMainWindow::closeEvent(e);
}

void MainWindow::on_listWidget_doubleClicked(QModelIndex index)
{
	QListWidgetItem* item = ui->listWidget->item(index.row());
	if(item)
	{
		ui->plainTextEdit->textCursor().insertText(item->text());
	}
}

void MainWindow::on_action_New_triggered()
{
	if(changed)
	{
		int res = QMessageBox::question(this, this->windowTitle(), "The document is modified.\nDo you want to save changes?", QMessageBox::Yes, QMessageBox::No, QMessageBox::Cancel);
		if(res == QMessageBox::Cancel)
		{
			return;
		}
		if(res == QMessageBox::Yes)
		{
			on_action_Save_triggered();
		}
	}

	ui->plainTextEdit->clear();
	fileName.clear();
	changed = false;
}

void MainWindow::on_action_Open_triggered()
{
	if(changed)
	{
		int res = QMessageBox::question(this, this->windowTitle(), "The document is modified.\nDo you want to save changes?", QMessageBox::Yes, QMessageBox::No, QMessageBox::Cancel);
		if(res == QMessageBox::Cancel)
		{
			return;
		}
		if(res == QMessageBox::Yes)
		{
			on_action_Save_triggered();
		}
	}

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
		{
			QString msg = "Error opening file:\n" + fname;
			QMessageBox::critical(this, this->windowTitle(), msg, QMessageBox::Ok);
		}
	}
}

void MainWindow::on_action_Save_triggered()
{
	if(fileName.isEmpty())
	{
		on_actionSave_as_triggered();
	}
	else
	{
		QFile f(fileName, this);
		if(f.open(QFile::WriteOnly | QFile::Text))
		{
			QString text = ui->plainTextEdit->toPlainText();

			/* --- Notepad UTF-8 zaglavlje
			QByteArray header;
			header.append((char)0xEF);
			header.append((char)0xBB);
			header.append((char)0xBF);
			f.write(header);
			*/

			f.write(text.toUtf8());

			f.close();

			changed = false;
		}
		else
		{
			QString msg = "Error opening file:\n" + fileName;
			QMessageBox::critical(this, this->windowTitle(), msg, QMessageBox::Ok);
		}
	}

}

void MainWindow::on_actionSave_as_triggered()
{
	QString fname = QFileDialog::getSaveFileName(this, this->windowTitle(), QDir::currentPath(), "Text Files (*.txt);;All Files (*.*)");
	if(!fname.isEmpty())
	{
		QFile f(fname);
		if(f.open(QFile::WriteOnly | QFile::Text))
		{
			QString text = ui->plainTextEdit->toPlainText();

			/* --- Notepad UTF-8 zaglavlje
			QByteArray header;
			header.append((char)0xEF);
			header.append((char)0xBB);
			header.append((char)0xBF);
			f.write(header);
			*/

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

void MainWindow::on_plainTextEdit_textChanged()
{
	changed = true;	
}

void MainWindow::on_plainTextEdit_copyAvailable(bool b)
{
	ui->actionCu_t->setEnabled(b);
	ui->action_Copy->setEnabled(b);
}

void MainWindow::on_plainTextEdit_redoAvailable(bool b)
{
	ui->action_Redo->setEnabled(b);
}

void MainWindow::on_plainTextEdit_undoAvailable(bool b)
{
	ui->action_Undo->setEnabled(b);
}

void MainWindow::updatePasteAction()
{
	ui->action_Paste->setEnabled(ui->plainTextEdit->canPaste());
	QTimer::singleShot(500, this, SLOT(updatePasteAction()));
}
