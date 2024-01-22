import argparse
import openpyxl
# import json

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("filename", help="xlsx文件名")
    args = parser.parse_args()

    # 读取xlsx文件
    wb = openpyxl.load_workbook(args.filename)

    # 获取数据宽度
    for row in wb.worksheets[0].rows:
        width = len(row)
        break

    # 获取有用的数据
    data = []
    dataIndex = 0
    for row in wb.worksheets[0].rows:
        dataIndex += 1
        if dataIndex > 1 and dataIndex <= width:
            rowData = []
            for i in range(width - 1):
                rowData.append(row[i + 1].value)
            data.append(rowData)

    # 生成json
    # 转化成二维json格式，字符串加上双引号
    jsonData = "["
    for i in range(len(data)):
        jsonData += "["
        for j in range(len(data[i])):
            if isinstance(data[i][j], str):
                jsonData += '"' + data[i][j] + '"'
            else:
                jsonData += str(data[i][j])
            if j != len(data[i]) - 1:
                jsonData += ","
        jsonData += "]"
        if i != len(data) - 1:
            jsonData += "," + "\n"
    jsonData += "]"
    # jsonData = json.dumps(data, ensure_ascii=False, indent=4) # 格式化输出

    # 新的文件名为原文件名去掉后缀加上.json，如原文件名为test.xlsx，则新文件名为test.json，如原文件名为./test.xlsx，则新文件名为test.json
    newFilename = args.filename.split(".")
    if len(newFilename) == 2:
        newFilename = newFilename[0] + ".json"
    else:
        newFilename = newFilename[-2] + ".json"
    
    # 如果文件名包含/或\，则去掉
    newFilename = newFilename.replace("/", "").replace("\\", "")

    # 写入文件
    with open(newFilename, "w", encoding="utf-8") as f:
        f.write(jsonData)

if __name__ == "__main__":
    main()