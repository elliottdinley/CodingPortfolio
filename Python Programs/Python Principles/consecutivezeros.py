def consecutive_zeros(num):
    count = 0
    highest = 0
    for x in num:
        if x == "0":
            count += 1
            if count > highest:
                highest = count
        else:
            count = 0
    return highest

print(consecutive_zeros(input("Enter number >")))
