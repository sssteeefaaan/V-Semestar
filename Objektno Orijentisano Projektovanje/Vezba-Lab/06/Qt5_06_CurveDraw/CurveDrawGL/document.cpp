#include "document.h"

#include <QFile>
#include <QDataStream>

Document::Document()
{
    m_currentCurve = NULL;
    m_modified = false;
}

Document::~Document()
{
    clear();
}

void Document::clear()
{
    if(m_currentCurve)
    {
        delete m_currentCurve;
        m_currentCurve = NULL;
    }

    for(int i=0; i<m_curves.size(); i++)
    {
        Curve* p = m_curves[i];
        m_curves[i] = NULL;
        if(p) delete p;
    }
    m_curves.clear();

    m_filePath.clear();
    m_modified = false;
}

bool Document::load(QString filePath)
{
    clear();

    QFile f(filePath);
    if(!f.open(QFile::ReadOnly)) return false;

    QDataStream stream(&f);

    quint16 code = 0;
    stream >> code;
    if(code != 0xCCDD) return false;

    quint16 size = 0;
    stream >> size;
    for(quint16 i=0; i<size; i++)
    {
        Curve* p = new Curve();
		p->load(stream);

        m_curves.append(p);
    }

    f.close();

    m_filePath = filePath;

    return true;
}

bool Document::save()
{
    finishCurve();

    QFile f(m_filePath);
    if(!f.open(QFile::WriteOnly)) return false;

    QDataStream stream(&f);

    quint16 code = 0xCCDD;
    stream << code;

    quint16 size = (quint16)m_curves.size();
    stream << size;
    for(int i=0; i<size; i++)
    {
		m_curves[i]->store(stream);
    }

    f.close();

    m_modified = false;

    return true;
}

void Document::draw(QPainter& p)
{
    for(int i=0; i<m_curves.size(); i++)
    {
        m_curves[i]->draw(p);
    }

    if(m_currentCurve)
    {
        m_currentCurve->draw(p);
    }
}

bool Document::isModified()
{
    return m_modified;
}

QString Document::filePath()
{
    return m_filePath;
}

void Document::setFilePath(QString filePath)
{
	m_filePath = filePath;
}

void Document::startNewCurve(quint8 width /*= 1*/, QRgb color /*= qRgb(0, 0, 0)*/)
{
    finishCurve();

    m_currentCurve = new Curve(width, color);
}

void Document::addPointToCurve(const QPoint& pt)
{
    if(m_currentCurve)
    {
		m_currentCurve->addPoint(pt);
    }
}

void Document::finishCurve()
{
    if(m_currentCurve)
    {
		if(m_currentCurve->isValid())
        {
            m_curves.append(m_currentCurve);
            m_modified = true;
        }
        else
        {
            delete m_currentCurve;
        }
        m_currentCurve = NULL;
    }
}

