#include "Summator.h"

namespace sm {
    Summator::Summator() {}

    
    Summator::Summator(int inner_a, int inner_b) {
        this->inner_a = inner_a;
        this->inner_b = inner_b;
    }

    
    Summator::~Summator() {}

    
    int Summator::getSum(int a, int b) {
        return a + b;
    }


    uint64_t Summator::get64Sum(uint64_t a, uint64_t b) {
        return a + b;
    }


    int Summator::getInnerSum() {
        return this->inner_a + this->inner_b;
    }
}