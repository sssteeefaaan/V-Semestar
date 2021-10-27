#ifndef SKIGAME_H
#define SKIGAME_H

#include "skiobstacle.h"
#include "skisanta.h"
#include <QPainter>

enum GameState{
    Paused,
    Playing,
    Won,
    Lost
};

class SkiGame : public QObject
{
    Q_OBJECT
public:
    SkiGame(QSize canvas = QSize(300, 200), int santaSpeed = 10, int obstacleAmount = 15, int mountainHeight = 60, QObject* parent = nullptr);
    SkiGame(const SkiGame& org);
    SkiGame& operator=(const SkiGame& org);
    virtual ~SkiGame();
    void clr();

private:
    QList<SkiObstacle*> obstacles;
    SkiSanta *santa;
    QSize canvas;
    int santaSpeed;
    int obstacleAmount;
    int mountainHeight;
    void setGame(QSize canvas = QSize(300, 200), int santaSpeed = 10, int obstacleAmount = 15, int mountainHeight = 60, GameState state = GameState::Paused, SkiSanta* santa = nullptr, const QList<SkiObstacle*> *obstacles = nullptr);

public:
    GameState state;
    void start();
    void tick();
    void moveSanta(bool dx);
    void draw(QPainter& paint);

public slots:
    void addObs();
    void setCanvas(QSize dim);
    void normSanta();
    void secPassed();

signals:
    void end();
};

#endif // SKIGAME_H
