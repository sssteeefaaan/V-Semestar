#include "view.h"

#include <QPainter>

View::View(QWidget *parent) :
		QGLWidget(QGLFormat(QGL::SampleBuffers), parent)
{    
	setAutoFillBackground(false);

	width = 10;
	color = qRgba(255, 0, 0, 128);		
}

void View::paintEvent(QPaintEvent* e)
{
	// Brisanje pozadine
	glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	// 3D crtanje
	/*
	glViewport(0, 0, rect().width(), rect().height());
	gluOrtho2D(rect().left(), rect().right(), rect().bottom(), rect().top());

	glBegin(GL_TRIANGLES);
	glColor3f(0.9f, 0.9f, 0.9f);
	glVertex2i(rect().left(), rect().bottom());
	glVertex2i(rect().center().x(), rect().top());
	glVertex2i(rect().right(), rect().bottom());
	glEnd();
	*/

	// 2D Crtanje
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	QPainter p(this);
	p.setRenderHint(QPainter::Antialiasing);
	//p.fillRect(rect(), Qt::white);

	doc.draw(p);
}

void View::mousePressEvent(QMouseEvent* e)
{
	doc.startNewCurve(width, color);
	doc.addPointToCurve(e->pos());
}

void View::mouseMoveEvent(QMouseEvent* e)
{
    doc.addPointToCurve(e->pos());
    repaint();
}

void View::mouseReleaseEvent(QMouseEvent* e)
{
    doc.finishCurve();
}
