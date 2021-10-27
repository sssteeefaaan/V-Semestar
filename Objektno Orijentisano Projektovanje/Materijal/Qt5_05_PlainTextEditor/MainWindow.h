#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QModelIndex>
#include <QSettings>

namespace Ui {
    class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

protected:
	virtual void	closeEvent(QCloseEvent* e);

private:
	Ui::MainWindow* ui;
	QSettings* settings;
	bool changed;
	QString	fileName;

private slots:
	void on_plainTextEdit_undoAvailable(bool b);
	void on_plainTextEdit_redoAvailable(bool b);
	void on_plainTextEdit_copyAvailable(bool b);
	void on_plainTextEdit_textChanged();
	void on_actionSave_as_triggered();
	void on_action_Save_triggered();
	void on_action_Open_triggered();
	void on_action_New_triggered();
	void on_listWidget_doubleClicked(QModelIndex index);
	void updatePasteAction();
};

#endif // MAINWINDOW_H
