#ifndef CHARTPOINTDIALOG_H
#define CHARTPOINTDIALOG_H

#include <QDialog>
#include <QMessageBox>
#include "Chartpoint.h"

namespace Ui {
class ChartPointDialog;
}

class ChartPointDialog : public QDialog
{
    Q_OBJECT

public:
    explicit                ChartPointDialog(QWidget *parent = nullptr);
    virtual                 ~ChartPointDialog();

    void                    getContent(QString& label, float& value, QColor& col);
    void                    setContent(ChartPoint* p);

private slots:
    void                    on_pushButtonC_clicked();

private:
    Ui::ChartPointDialog*   ui;
};

#endif // CHARTPOINTDIALOG_H
