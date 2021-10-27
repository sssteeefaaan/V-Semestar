#include "widget.h"
#include "ui_widget.h"

Widget::Widget(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::Widget)
    , cl(new CalculatorLogic(this))
{
    ui->setupUi(this);

    connect(ui->pushButton0, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton1, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton2, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton3, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton4, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton5, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton6, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton7, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton8, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButton9, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));

    connect(ui->pushButtonPlus, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonMin, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonMul, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonDiv, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonSqrt, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));

    connect(ui->pushButtonClear, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonBack, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonSign, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonDot, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));
    connect(ui->pushButtonEq, SIGNAL(clicked()), cl, SLOT(onBttnClicked()));

    connect(cl, SIGNAL(resultChanged(QString)), ui->displayResult, SLOT(setText(QString)));
    connect(cl, SIGNAL(resultHistoryChanged(QString)), ui->displayHistory, SLOT(appendPlainText(QString)));
    connect(cl, SIGNAL(resultHistoryCleared()), ui->displayHistory, SLOT(clear()));

    cl->resSet("0");
}

Widget::~Widget()
{
    delete ui;
}

// Estetika (Da dugmici za binarne operacije ostanu "pritisnuti", kako bi se znalo koju operaciju izvrsavamo)
void Widget::uncheckOthers()
{
    ui->pushButtonPlus->setChecked(false);
    ui->pushButtonMin->setChecked(false);
    ui->pushButtonMul->setChecked(false);
    ui->pushButtonDiv->setChecked(false);
}

void Widget::on_pushButtonPlus_clicked()
{
    uncheckOthers();
    ui->pushButtonPlus->setChecked(true);
}

void Widget::on_pushButtonMin_clicked()
{
    uncheckOthers();
    ui->pushButtonMin->setChecked(true);
}

void Widget::on_pushButtonMul_clicked()
{
    uncheckOthers();
    ui->pushButtonMul->setChecked(true);
}

void Widget::on_pushButtonDiv_clicked()
{
    uncheckOthers();
    ui->pushButtonDiv->setChecked(true);
}

void Widget::on_pushButtonSqrt_clicked()
{
    uncheckOthers();
}

void Widget::on_pushButtonEq_clicked()
{
    uncheckOthers();
}
