#include "Widget.h"
#include "ui_Widget.h"

Widget::Widget(QWidget *parent) :
    QWidget(parent),
	ui(new Ui::Widget),
	tempConverter(new TempConverter(this))
{
    ui->setupUi(this);

	connect(ui->dialCelsius, SIGNAL(valueChanged(int)), tempConverter, SLOT(setTempCelsius(int)));
	connect(ui->dialFahrenheit, SIGNAL(valueChanged(int)), tempConverter, SLOT(setTempFahrenheit(int)));
	connect(tempConverter, SIGNAL(tempCelsiusChanged(int)), ui->dialCelsius, SLOT(setValue(int)));
	connect(tempConverter, SIGNAL(tempFahrenheitChanged(int)), ui->dialFahrenheit, SLOT(setValue(int)));

	tempConverter->setTempCelsius(0);
}

Widget::~Widget()
{
    delete ui;
}
