def largest_difference(numlist):
    maxno = 0
    for x in numlist:
        if x > maxno:
            maxno = x
    minno = maxno
    for x in numlist:
        if x < minno:
            minno = x

    return maxno - minno

nums = [3, 12, 4, 7, 3, 6]

print(largest_difference(nums))
