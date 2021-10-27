#ifndef DOCUMENT_H
#define DOCUMENT_H

#include <QString>
#include "Curve.h"

class Document
{
public:
    Document();
    virtual ~Document();

public:
    void    clear();
    bool    load(QString filePath);
    bool    save();

    void    draw(QPainter& p);

    bool    isModified();
    QString filePath();
    void    setFilePath(QString filepath);

    void    startNewCurve(quint8 width = 1, QColor color = qRgb(0, 0, 0));
    void    addPointToCurve(const QPoint& pt);
    void    finishCurve();

private:
    QVector<Curve*> m_curves;
    Curve*          m_currCurve;

    QString         m_filePath;
    bool            m_mod;
};

#endif // DOCUMENT_H
