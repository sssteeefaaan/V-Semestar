#include "CalculatorLogic.h"

CalculatorLogic::CalculatorLogic(QWidget*parent)
    :QWidget(parent)
{   calcReset();    }

CalculatorLogic::~CalculatorLogic(){}

void CalculatorLogic::resSet(QString s)
{
    res=s;
    emit resultChanged(res);
}

void CalculatorLogic::accPush()
{
    acc=res;
    res="";
    emit resultChanged(acc);
}

/*
    Pokusao sam sto blize moguce da izimitiram Windows calculator aplikaciju:
        - Zeleo sam da na pocetku na displeju bude 0
        - Po unosu brojeva da se ta nula brise i zamenjuje ciframa koje unosi korisnik
        - Po pritisku jednog od binarnih operatora:
            - Ukoliko je rec o prvom operandu (acc je prazan) pamti se sadrzaj lineEdit-a (prenosi res -> acc)
            - Ukoliko je rec o drugom operandu (acc nije prazan) onda se izvrsava operacija nad dva operanda
              a to je ujedno i prvi operand za sledeci operator
        - Po pritisku digmeta jednako:
            - Izvrsava se poslednja pritisnuta operacija i sadrzaj akumulatora brise

    Zeleo sam da odradim zadatak na malo drugaciji nacin, nadam se da nije problem.
*/
void CalculatorLogic::onBttnClicked()
{
    if(sender()->objectName()[10]>='0' && sender()->objectName()[10]<='9'){
        if(res=="0")
            resSet((QString)sender()->objectName()[10]);
        else
            resSet(res + sender()->objectName()[10]);
        return;
    }

    if(sender()->objectName()=="pushButtonPlus")
    {
        op='+';
        if(!acc.isEmpty())
            add();
        else
            history+=res;
        accPush();
        return;
    }
    if(sender()->objectName()=="pushButtonMin")
    {
        op='-';
        if(!acc.isEmpty())
            sub();
        else
            history+=res;
        accPush();
        return;
    }
    if(sender()->objectName()=="pushButtonMul")
    {
        op='*';
        if(!acc.isEmpty())
            mul();
        else
            history+=res;
        accPush();
        return;
    }
    if(sender()->objectName()=="pushButtonDiv")
    {
        op='/';
        bool check=true;
        if(!acc.isEmpty())
            check = div();
        else
            history+=res;
        if(check)
            accPush();
        return;
    }
    if(sender()->objectName()=="pushButtonSqrt")
    {
        if(res.toDouble()<0)
        {
            calcReset();
            emit resultChanged("SyntaxError");
            return;
        }
        history += "sqrt( " + res + " ) ";
        resSet(QString::number(sqrt(res.toDouble())));
        return;
    }

    if(sender()->objectName()=="pushButtonClear"){
        calcReset();
        emit resultChanged(res);
        emit resultHistoryCleared();
        return;
    }
    if(sender()->objectName()=="pushButtonBack"){
        res.truncate(res.length()-1);
        emit resultChanged(res);
        return;
    }
    if(sender()->objectName()=="pushButtonSign"){
        if(res[0]!="-")
            res="-"+res;
        else
            res=res.mid(1);
        emit resultChanged(res);
        return;
    }
    if(sender()->objectName()=="pushButtonDot"){
        if(res.contains("."))
            return;
        resSet(res+".");
        return;
    }
    if(sender()->objectName()=="pushButtonEq"){
        if(!acc.isEmpty())
        {
            if(doCommand())
            {
                history+= " = " + res;
                emit resultChanged(res);
                emit resultHistoryChanged(history);
                acc=history="";
            }
        }
        return;
    }
}

bool CalculatorLogic::doCommand()
{
    switch(op)
    {
    case('+'):
        add();
        return true;
    case('-'):
        sub();
        return true;
    case('*'):
        mul();
        return true;
    case('/'):
        return div();
    default:
        return false;
    }
}

void CalculatorLogic::calcReset(){
    res=acc=history="";
}

void CalculatorLogic::add()
{
    if(res!="")
        history+=" + " + res;
    res=QString::number(acc.toDouble()+res.toDouble());
}

void CalculatorLogic::sub()
{
    if(res!="")
        history+=" - " + res;
    res=QString::number(acc.toDouble() - res.toDouble());
}

void CalculatorLogic::mul()
{
    if(res!="")
        history+=" * " + res;
    res=QString::number(acc.toDouble() * res.toDouble());
}

bool CalculatorLogic::div()
{
    if(res=="0")
    {
        calcReset();
        emit resultChanged("SyntaxError");
        return false;
    }
    if(res!="")
        history+=" / " + res;
    res=QString::number(acc.toDouble() / res.toDouble());
    return true;
}
