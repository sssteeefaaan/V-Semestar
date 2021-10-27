#include "TempConverter.h"

TempConverter::TempConverter(QObject *parent) :
    QObject(parent)
{
	m_tempCelsius = -1000; // neka nevalidna vrednost
}

int TempConverter::tempCelsius() const
{
	return m_tempCelsius;
}

int TempConverter::tempFahrenheit() const
{
	return (9.0/5.0)*m_tempCelsius + 32;
}

void TempConverter::setTempCelsius(int tempCelsius)
{
	if(m_tempCelsius == tempCelsius)
		return;

	m_tempCelsius = tempCelsius;
	emit tempCelsiusChanged(m_tempCelsius);
	emit tempFahrenheitChanged(tempFahrenheit());
}

void TempConverter::setTempFahrenheit(int tempFahrenheit)
{
	int tempCelsius = (5.0/9.0)*(tempFahrenheit - 32);
	setTempCelsius(tempCelsius);
}
