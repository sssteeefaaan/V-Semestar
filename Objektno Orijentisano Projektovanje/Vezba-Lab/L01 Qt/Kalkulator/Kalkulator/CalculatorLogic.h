#ifndef CALCULATORLOGIC_H
#define CALCULATORLOGIC_H

#include <QWidget>

class CalculatorLogic : public QWidget
{
    Q_OBJECT
public:
    CalculatorLogic(QWidget * parent = nullptr);
    virtual ~CalculatorLogic();

signals:
    void resultChanged(QString);
    void resultHistoryChanged(QString);
    void resultHistoryCleared();

public slots:
    void onBttnClicked();   // "Mozak" kalkulatora

public:
    void resSet(QString);
    void accPush();
    bool doCommand(); //Imao sam drugaciju zamisao za funkcionisanje, pa ova funkcija ima drugaciji potpis

private:
    void add();
    void sub();
    void mul();
    bool div();
    void calcReset();

    QString res;    // u 90% slucaja je ovo sadrzaj displeja rezultata (ponekad je i akumulator)
    QString acc;    // akumulator (skladisti prvi operand za binarne operatore)
    QString history;
    char op;        // cuva znak binarne operacije dok se unosi drugi operand
};

#endif // CALCULATORLOGIC_H
