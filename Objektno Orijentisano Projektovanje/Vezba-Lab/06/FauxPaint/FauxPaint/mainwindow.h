#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
    bool askToSave();

protected:
    void closeEvent(QCloseEvent* e);

private slots:
    void on_actionNew_triggered();
    void on_actionOpen_triggered();
    void on_actionSave_triggered();
    void on_actionSave_As_triggered();
    void on_actionExit_triggered();
    void on_action1px_triggered();
    void on_action2px_triggered();
    void on_action5px_triggered();
    void on_action10px_triggered();
    void on_actionBlack_triggered();
    void on_actionWhite_triggered();
    void on_actionRed_triggered();
    void on_actionBlue_triggered();
    void on_actionGreen_triggered();
    void on_actionMore_Colors_triggered();
    void on_actionMore_Sizes_triggered();
    void updateButtons();
    void on_actionRainbow_triggered();
    void colorInc();
};
#endif // MAINWINDOW_H
