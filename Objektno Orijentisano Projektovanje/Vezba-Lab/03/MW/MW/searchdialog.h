#ifndef SEARCHDIALOG_H
#define SEARCHDIALOG_H

#include <QDialog>
#include <QString>

namespace Ui {
class SearchDialog;
}

class SearchDialog : public QDialog
{
    Q_OBJECT

public:
    explicit SearchDialog(QWidget *parent = nullptr);
    ~SearchDialog();

    QString getSrchWord();

private:
    Ui::SearchDialog *ui;
};

#endif // SEARCHDIALOG_H
