#include "TConverter.h"

TConverter::TConverter(QObject *parent):
    QObject(parent)
{
    m_tempC = -1000;
}

int TConverter::tempC() const
{return m_tempC;}

int TConverter::tempK() const
{return m_tempC+273;}

int TConverter::tempF() const
{return m_tempC*(9.0/5.0) + 32;}

void TConverter::setTempC(int tempC)
{
    if(m_tempC == tempC)
        return;

    m_tempC = tempC;

    emit tempCChange(m_tempC);
    emit tempKChange(tempK());
    emit tempFChange(tempF());
}

void TConverter::setTempF(int tempF)
{setTempC((5.0/9.0)*(tempF - 32));}

void TConverter::setTempK(int tempK)
{setTempC(tempK-273);}
