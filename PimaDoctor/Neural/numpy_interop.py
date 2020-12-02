import numpy as np
import ctypes

def to_numpy(ptr, bytes, dtype, shape):
    return np.frombuffer((ctypes.c_uint8*(bytes)).from_address(ptr), dtype).reshape(shape)