#ifndef SKISPORTDIALOG_H
#define SKISPORTDIALOG_H

#include <QDialog>

namespace Ui {
class SkiSportDialog;
}

class SkiSportDialog : public QDialog
{
    Q_OBJECT

public:
    explicit SkiSportDialog(QWidget *parent = nullptr);
    ~SkiSportDialog();
    void getData(int& santaSpeed, int& obstacleAmount, int& mountainHeight, QString& url);
    int readSS();
    int readOA();
    int readMH();
    QString readT();

private:
    Ui::SkiSportDialog *ui;
};

#endif // SKISPORTDIALOG_H
