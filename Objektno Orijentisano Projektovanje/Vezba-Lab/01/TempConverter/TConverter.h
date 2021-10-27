#ifndef TCONVERTER_H
#define TCONVERTER_H

#include <QObject>

class TConverter : public QObject
{
    Q_OBJECT

public:
    explicit TConverter(QObject *parent = 0);

    int tempK() const;
    int tempC() const;
    int tempF() const;

signals:
    void tempCChange(int);
    void tempFChange(int);
    void tempKChange(int);

public slots:
    void setTempC(int tempC);
    void setTempF(int tempF);
    void setTempK(int tempK);

private:
    int m_tempC;
};

#endif // TCONVERTER_H
