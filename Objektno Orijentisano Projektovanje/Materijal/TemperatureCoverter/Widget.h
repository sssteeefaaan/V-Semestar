#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include "TempConverter.h"

namespace Ui {
    class Widget;
}

class Widget : public QWidget
{
    Q_OBJECT

public:
    explicit Widget(QWidget *parent = 0);
    ~Widget();

private:
    Ui::Widget *ui;
	TempConverter *tempConverter;
};

#endif // WIDGET_H
