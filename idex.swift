import Foundation

func fourSum(_ nums: [Int], _ target: Int) -> [[Int]] {
    guard nums.count >= 4 else {
        return []
    }

    let sortedNums = nums.sorted()

    var result: [[Int]] = []

    for i in 0..<sortedNums.count - 3 {
        if i > 0 && sortedNums[i] == sortedNums[i - 1] {
            continue
        }

        for j in i + 1..<sortedNums.count - 2 {
            if j > i + 1 && sortedNums[j] == sortedNums[j - 1] {
                continue
            }

            var left = j + 1
            var right = sortedNums.count - 1

            while left < right {
                let sum = sortedNums[i] + sortedNums[j] + sortedNums[left] + sortedNums[right]

                if sum == target {
                    result.append([sortedNums[i], sortedNums[j], sortedNums[left], sortedNums[right]])

                    while left < right && sortedNums[left] == sortedNums[left + 1] {
                        left += 1
                    }

                    while left < right && sortedNums[right] == sortedNums[right - 1] {
                        right -= 1
                    }

                    left += 1
                    right -= 1
                } else if sum < target {
                    left += 1
                } else {
                    right -= 1
                }
            }
        }
    }

    return result
}

// Example usage:
let result1 = fourSum([1, 0, -1, 0, -2, 2], 0)
print(result1)  // Output: [[-2, -1, 1, 2], [-2, 0, 0, 2], [-1, 0, 0, 1]]

let result2 = fourSum([2, 2, 2, 2, 2], 8)
print(result2)  // Output: [[2, 2, 2, 2]]



