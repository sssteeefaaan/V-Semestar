#ifndef CHARTDOC_H
#define CHARTDOC_H

#include <QObject>
#include <QFile>
#include <QFileDialog>
#include <QTextStream>
#include <QColorDialog>
#include "Chartpoint.h"

// Klasa odgovorna za skladištenje izgleda chart-a, njegovo iscrtavanje i memorisanje/čitanje iz .txt fajla
class ChartDoc : public QObject
{
    Q_OBJECT
public:
    explicit ChartDoc(QObject *parent = nullptr);
    virtual ~ChartDoc();

private:
    QList<ChartPoint*>     m_points;
    bool                   m_mod;
    QString                m_filePath;

public:
    // Rad sa fajl sistemom i "brisanje" elemenata
    bool                   loadChartFromFile(QString file);
    bool                   saveChartToFile();
    QString                filePath();
    void                   setFilePath(QString path);
    void                   clear();

    // Iscrtavanje, dodavanje novih chart-ova, provera da li je naišla izmena kao i njeno setovanje
    void                   draw(QPainter& p,int width, int height);
    void                   drawSingleBarChart(QPainter& p, int propX, int propY, int pos);
    void                   addNew(ChartPoint *p);
    bool                   isMod();
    void                   setMod(bool b);

    // Provera da li je "izabran" neki od chart-ova
    bool                   select(QPoint point, int width, int height);

    // Signali za promenu podataka u chart-u, kao i odabir jednog od chart-ova
signals:
    void                   chartDataChanged();
    void                   selected(ChartPoint*);

};

#endif // CHARTDOC_H
