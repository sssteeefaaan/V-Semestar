#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QModelIndex>
#include <QSettings>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

protected:
    virtual void closeEvent(QCloseEvent* e);

private:
    Ui::MainWindow* ui;
    QSettings* settings;
    bool changed;
    QString fileName;

    void wannaSave();

private slots:
    void on_plainTextEdit_undoAvailable(bool b);
    void on_plainTextEdit_redoAvailable(bool b);

    void on_plainTextEdit_copyAvailable(bool b);
    void on_plainTextEdit_cutAvailable(bool b);
    void updatePasteAction();

    void on_plainTextEdit_textChanged();

    void on_actionNew_triggered();
    void on_actionOpen_triggered();
    void on_actionSave_triggered();
    void on_actionSave_As_triggered();

    void on_listWidget_doubleClicked(const QModelIndex &index);
    void on_actionCut_triggered();
};
#endif // MAINWINDOW_H
