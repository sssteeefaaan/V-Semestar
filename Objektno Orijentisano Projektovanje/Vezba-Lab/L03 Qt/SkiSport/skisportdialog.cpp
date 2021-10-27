#include "skisportdialog.h"
#include "ui_skisportdialog.h"

SkiSportDialog::SkiSportDialog(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::SkiSportDialog)
{
    ui->setupUi(this);
}

SkiSportDialog::~SkiSportDialog()
{
    if(ui)
    { delete ui; ui = 0; }
}

void SkiSportDialog::getData(int &santaSpeed, int &obstacleAmount, int &mountainHeight, QString& url)
{
    santaSpeed = readSS();
    obstacleAmount = readOA();
    mountainHeight = readMH();
    url = readT();
}

int SkiSportDialog::readSS()
{
    switch(ui->comboBoxSS->currentIndex())
    {
    case 0:
        return 25;
    case 1:
        return 50;
    case 2:
        return 75;
    case 3:
        return 100;
    case 4:
        return 125;
    case 5:
        return 150;
    }
    return -1;
}

int SkiSportDialog::readOA()
{
    switch(ui->comboBoxOA->currentIndex())
    {
    case 0:
        return 10;
    case 1:
        return 15;
    case 2:
        return 20;
    case 3:
        return 30;
    case 4:
        return 50;
    }
    return -1;
}

int SkiSportDialog::readMH()
{
    switch(ui->comboBoxMH->currentIndex())
    {
    case 0:
        return 30;
    case 1:
        return 60;
    case 2:
        return 90;
    case 3:
        return 120;
    case 4:
        return 240;
    }
    return -1;
}

QString SkiSportDialog::readT()
{
    switch(ui->comboBoxT->currentIndex())
    {
    case 0:
        return "https://docs.google.com/uc?export=download&id=1xxEBPVcIsesc2TUReix7ENoe-70aKO-e";
    case 1:
        return "https://docs.google.com/uc?export=download&id=1BJRFs_QI5fHL4XuHs0tYpCp2ijVjnEzb";
    case 2:
        return "https://docs.google.com/uc?export=download&id=1YCHWQuc14R_UI0pApBGd-HzP1DAbhIrv";
    case 3:
        return "https://docs.google.com/uc?export=download&id=1-Y3HqbAp8_Z4uX7d6g2AiE-0tSLlG8ff";
    case 4:
        return "https://docs.google.com/uc?export=download&id=1lfP38s0JLOZD7nkxQoJ6cUR1S7WdPVAv";
    case 5:
        return "https://docs.google.com/uc?export=download&id=1usIPi-PkVONqBva2EOnCOmpGd4Xh5hxZ";
    case 6:
        return "https://docs.google.com/uc?export=download&id=17_w6wY1Qzoy9YdoSLzTiHwNcL86bLWY8";
    case 7:
        return "https://docs.google.com/uc?export=download&id=1zeHypIM1hSYMWswbVaVZifo4IVrQVDZn";
    case 8:
        return "https://docs.google.com/uc?export=download&id=1GKxWs1FWUZOX7rhDEB316RQspb_VOsH2";
    case 9:
        return "https://docs.google.com/uc?export=download&id=1DcwvZjU0R5_6_BID3dOzscamCy8EkKpB";
    case 10:
        return "https://docs.google.com/uc?export=download&id=181r2JzZYXX3hz-W0loHS5MN4BXk6Q4id";
    case 11:
        return "https://docs.google.com/uc?export=download&id=1vj89gv-ABuNy9XdddzOsrY7HZvLAK8cS";
    case 12:
        return "https://docs.google.com/uc?export=download&id=1EcpN-dDNvsAEIkWBS9U5PPE327JKXo2m";
    case 13:
        return "https://docs.google.com/uc?export=download&id=1Tra-FQ0ZwIE3uVG3rd2FcgeAMUi8Ztvp";
    }
    return "";
}
