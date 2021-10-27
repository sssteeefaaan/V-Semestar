#ifndef DOCUMENT_H
#define DOCUMENT_H

#include <QString>
#include "curve.h"

class Document
{
public:
    Document();
    virtual ~Document();

// Methods
public:
    void    clear();
    bool    load(QString filePath);
    bool    save();

    void    draw(QPainter& p);

    bool    isModified();
	QString filePath();
	void	setFilePath(QString filePath);

    void    startNewCurve(quint8 width = 1, QRgb color = qRgb(0, 0, 0));
    void    addPointToCurve(const QPoint& pt);
    void    finishCurve();

private:


// Attributes
private:
    QVector<Curve*> m_curves;
    Curve*          m_currentCurve;

    QString         m_filePath;
    bool            m_modified;
};

#endif // DOCUMENT_H
