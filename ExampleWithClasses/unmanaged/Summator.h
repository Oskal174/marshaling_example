#pragma once

#include <iostream>


namespace sm  { // serious math
    class Summator {
    public:
        Summator();
        Summator(int inner_a, int inner_b);
        
        ~Summator();
    
        int getSum(int a, int b);
        uint64_t get64Sum(uint64_t a, uint64_t b);
        int getInnerSum();

    private:
        int inner_a;
        int inner_b;
    };
}