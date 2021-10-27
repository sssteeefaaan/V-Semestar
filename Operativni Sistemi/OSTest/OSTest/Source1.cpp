//#include <thread>
//#include <stdio.h>
//#include <mutex>
//#include <condition_variable>
//using namespace std;
//
//class Monitor {
//private:
//	mutex mtx;
//	condition_variable notfull, notempty;
//public:
//	char* buffer;
//	int n;
//	int in;
//	int out;
//	bool second;
//	Monitor(int n = 0) {
//		this->in = this->out = 0;
//		buffer = new char[this->n = n];
//		second = false;
//	}
//	~Monitor()
//	{
//		if (buffer)delete[] buffer;
//	}
//
//	inline void append(char s)
//	{
//		unique_lock<mutex> lock(mtx);
//		if(in)
//		buffer[in] = s;
//		in = (in + 1) % n;
//		if((in + 1)%n == out)
//			notempty.notify_one();
//	}
//
//	inline void take(char& ret)
//	{
//		unique_lock<mutex> lock(mtx);
//		second = not second;
//		ret = buffer[out];
//		out = (out + 1) % n;
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