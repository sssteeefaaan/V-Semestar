#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "Chartdoc.h"
#include "Chartpointdialog.h"

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    virtual ~MainWindow();

private:
    Ui::MainWindow*     ui;

    bool                askToSave();
    void                closeEvent(QCloseEvent* e);

private slots:
    void                on_actionInsert_triggered();
    void                selected(ChartPoint*);
    void                on_action_Load_Chart_triggered();
    void                on_action_Save_Chart_triggered();
    void                on_actionSave_As_triggered();
};
#endif // MAINWINDOW_H
