// Original: int bitcount(unsigned x), "The C Programming Language", page 50

export const bitCount = (x: number): number => _bitCount(x, 0);

const _bitCount = (x: number, iterations: number): number =>
    x == 0 || iterations == 32
        ? 0
        : _bitCount(x >> 1, ++iterations) + (x & 1);

export const byteCopy = (src: Uint8Array, dst: Uint8Array, size: number) : void => src
    .slice(0, Math.min(size, Math.min(src.length, dst.length)))
    .forEach((value, i) => dst[i] = value);

export function byteZero(a: Uint8Array, size: number) : void {
    a.fill(0, 0, Math.min(size, a.length));
}

export function byteSet(a: Uint8Array, value: number, size: number) : void {
    a.fill(value, 0, Math.min(size, a.length));
}