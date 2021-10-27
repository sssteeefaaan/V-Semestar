#ifndef WIDGET_H
#define WIDGET_H

#include "CalculatorLogic.h"

QT_BEGIN_NAMESPACE
namespace Ui { class Widget; }
QT_END_NAMESPACE

class Widget : public QWidget
{
    Q_OBJECT

public:
    Widget(QWidget *parent = nullptr);
    ~Widget();

private slots:
    void on_pushButtonPlus_clicked();
    void on_pushButtonMin_clicked();
    void on_pushButtonMul_clicked();
    void on_pushButtonDiv_clicked();
    void on_pushButtonSqrt_clicked();
    void on_pushButtonEq_clicked();

private:
    Ui::Widget *ui;
    CalculatorLogic *cl;

    void uncheckOthers();
};
#endif // WIDGET_H
