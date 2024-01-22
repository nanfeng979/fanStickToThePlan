import json
import sys

newJsonData = ""

def convert_directions(json_array):
    global newJsonData
    # 打印
    newJsonData = json.dumps(json_array, ensure_ascii=False, indent=4)
    newJsonData = newJsonData.replace('"up"', "1").replace('"down"', "2").replace('"left"', "3").replace('"right"', "4")

def load_json_from_file(file_path):
    try:
        with open(file_path, 'r') as file:
            data = json.load(file)
        return data
    except Exception as e:
        print(f"Error loading JSON from file: {e}")
        sys.exit(1)

def save_json_to_file(data, file_path):
    try:
        with open(file_path, 'w') as file:
            # 写入newJsonData
            file.write(data)
    except Exception as e:
        print(f"Error saving JSON to file: {e}")
        sys.exit(1)

if __name__ == "__main__":
    # 检查是否提供了文件路径作为参数
    if len(sys.argv) != 2:
        print("Usage: python script.py <file_path>")
        sys.exit(1)

    file_path = sys.argv[1]

    # 从文件加载JSON数据
    json_array = load_json_from_file(file_path)

    # 转换方向
    convert_directions(json_array)

    # 覆盖原始文件
    save_json_to_file(newJsonData, file_path)

    print(f"Conversion completed. Original file {file_path} has been overwritten.")
