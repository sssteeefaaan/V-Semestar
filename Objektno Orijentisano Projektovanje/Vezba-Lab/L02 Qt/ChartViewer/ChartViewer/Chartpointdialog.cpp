#include "Chartpointdialog.h"
#include "ui_Chartpointdialog.h"
#include <QColorDialog>
#include <QString>

ChartPointDialog::ChartPointDialog(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::ChartPointDialog)
{
    ui->setupUi(this);
    ui->lineEditV->setValidator(new QDoubleValidator(0, 100, 2, this));
}

ChartPointDialog::~ChartPointDialog()
{
    delete ui;
}

void ChartPointDialog::getContent(QString &label, float &value, QColor &col)
{
    label = ui->lineEditL->text();
    value = ui->lineEditV->text().toFloat();
    col = QColor(ui->lineEditC->text());
}

void ChartPointDialog::setContent(ChartPoint *p)
{
    ui->lineEditL->setText(p->getLabel());
    ui->lineEditV->setText(QString::number(p->getValue()));
    ui->lineEditC->setText(p->getColor().name());
}

void ChartPointDialog::on_pushButtonC_clicked()
{
    QColor col = QColorDialog::getColor(Qt::white,this,"Select Color");
    ui->lineEditC->setText(col.name());
}
