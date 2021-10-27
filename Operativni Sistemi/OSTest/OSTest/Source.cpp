//#include <thread>
//#include <stdio.h>
//#include <mutex>
//#include <condition_variable>
//using namespace std;
//
//class Semaphore {
//private:
//	mutex mtx;
//	condition_variable cv;
//public:
//	int count;
//
//	Semaphore(int count_ = 0)
//		: count(count_) {}
//
//	inline void signal()
//	{
//		unique_lock<mutex> lock(mtx);
//		count++;
//		cv.notify_one();
//	}
//
//	inline void wait()
//	{
//		unique_lock<mutex> lock(mtx);
//
//		while (count == 0) {
//			cv.wait(lock);
//		}
//		count--;
//	}
//};
//
//// int a = 0;
//// mutex m;
//Semaphore s;
//
//void P1()
//{
//	/*for (int i = 0; i < 1000000; i++)
//	{
//		m.lock();
//		a++;
//		m.unlock();
//	}*/
//
//	printf("Hello 1\n");
//	s.signal();
//}
//void P2()
//{
//	/*for (int i = 0; i < 1000000; i++)
//	{
//		m.lock();
//		a++;
//		m.unlock();
//	}*/
//
//	s.wait();
//	printf("Hello 2\n");
//}
//
//int main(int argc, char** argv)
//{
//	s.count = 0;
//	thread t1(P1), t2(P2);
//
//	/*t1.join();
//	t2.join();
//	printf("Vrednost a = %d\n", a);*/
//
//	while (true);
//
//	return 0;
//}