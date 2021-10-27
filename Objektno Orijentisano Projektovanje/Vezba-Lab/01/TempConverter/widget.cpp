#include "widget.h"
#include "ui_widget.h"

Widget::Widget(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::Widget)
    , tempConverter(new TConverter(this))
{
    ui->setupUi(this);

    connect(ui->dialC, SIGNAL(valueChanged(int)), tempConverter, SLOT(setTempC(int)));
    connect(ui->dialF, SIGNAL(valueChanged(int)), tempConverter, SLOT(setTempF(int)));
    connect(ui->dialK, SIGNAL(valueChanged(int)), tempConverter, SLOT(setTempK(int)));

    connect(tempConverter, SIGNAL(tempCChange(int)), ui->dialC, SLOT(setValue(int)));
    connect(tempConverter, SIGNAL(tempFChange(int)), ui->dialF, SLOT(setValue(int)));
    connect(tempConverter, SIGNAL(tempKChange(int)), ui->dialK, SLOT(setValue(int)));

    tempConverter->setTempC(0);
}

Widget::~Widget()
{
    delete ui;
}

