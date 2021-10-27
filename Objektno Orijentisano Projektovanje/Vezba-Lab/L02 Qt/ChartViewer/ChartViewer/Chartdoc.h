#ifndef CHARTDOC_H
#define CHARTDOC_H

#include <QObject>
#include <QFile>
#include <QFileDialog>
#include <QTextStream>
#include <QColorDialog>
#include "Chartpoint.h"

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
    bool                   loadChartFromFile(QString file);
    bool                   saveChartToFile();
    void                   clear();

    void                   draw(QPainter& p,int width, int height);
    void                   select(QPoint& point);
    void                   addNew(ChartPoint *p);
    bool                   isMod();
    void                   setMod(bool b);

    QString                filePath();
    void                   setFilePath(QString path);

    bool                   select(QPoint point, int width, int height);

signals:
    void                   chartDataChanged();
    void                   selected(ChartPoint*);

};

#endif // CHARTDOC_H
