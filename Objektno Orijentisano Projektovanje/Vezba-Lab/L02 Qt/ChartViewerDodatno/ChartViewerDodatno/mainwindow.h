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

    // Ispituje da li je došlo do izmena u prethodno sačuvanim podacima
    bool                askToSave();
    // Definiše šta se dešava kada na neki način izađemo iz programa
    void                closeEvent(QCloseEvent* e);

private slots:
    void                on_actionInsert_triggered();    // Dodatno, opcija za direktno upisivanje vrednosti, bez definisanja .txt fajla
    void                selected(ChartPoint*);      // Dodato, moglo je i jednostavnije, ali sam se igrao sa signalima i slotovima
    void                on_action_Load_Chart_triggered();
    void                on_action_Save_Chart_triggered();
    void                on_actionSave_As_triggered();
};
#endif // MAINWINDOW_H
