#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

namespace Ui {
    class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private:
    Ui::MainWindow *ui;    

    bool askToSave();

protected:
    void closeEvent(QCloseEvent* e);

private slots:
	void on_action_Blue_triggered();
	void on_action_Green_triggered();
	void on_action_Red_triggered();
	void on_action_Black_triggered();
	void on_action_10_triggered();
	void on_action_5_triggered();
	void on_action_3_triggered();
	void on_action_1_triggered();
	void on_actionE_xit_triggered();
    void on_actionSave_As_triggered();
    void on_action_Save_triggered();
    void on_action_Open_triggered();
    void on_action_New_triggered();
	void updateButtons();
};

#endif // MAINWINDOW_H
