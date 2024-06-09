export const sum = (numbers: number[]): number => numbers
    .reduce((a, b) => a + b, 0)

export const max = (numbers: number[]): number => numbers
    .slice(1)
    .reduce((a, b) => Math.max(a, b), numbers[0]);

export const min = (numbers: number[]): number => numbers
    .slice(1)
    .reduce((a, b) => Math.min(a, b), numbers[0]);

export const indexOf = (numbers: number[], numberToFind:number): number => numbers
    .map((number, index) => {
        return { number: number, index: index }
    })
    .filter(x => x.number === numberToFind)
    .map(x => x.index)[0]; //Lazy

export const contains = (numbers: number[], numberToFind:number): boolean => numbers
    .filter(number => number === numberToFind)
    .length > 0;

export const reverse = (numbers: number[]): number[] => numbers
    .map(((number, index) => numbers[numbers.length - 1 - index]));

export const copy = (numbers: number[]): number[] => numbers
    .map(number => number);

export const countOccurrences = (numbers: number[], numberToFind:number): number => numbers
    .filter(number => number === numberToFind)
    .length;

export function getAmountOfPrimes(N: number): number
{
    let primes = Array<boolean>(N / 2);

    primes = primes.fill(true);
    primes[0] = false; // 1 is not a prime number

    for(let i = 3; i * i <= N; i += 2) {
        if (primes[(i / 2) >> 0]) {
            for(let j = i * i; j <= N; j += (2*i))
                primes[(j / 2) >> 0] = false;
        }
    }

    let count = 1; // Count 2 as a prime number
    for(let i = 1; i < primes.length; i++) {
        if (primes[i])
            count++;
    }

    return count;
}