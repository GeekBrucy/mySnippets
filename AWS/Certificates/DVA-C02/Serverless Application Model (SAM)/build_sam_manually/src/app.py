# code is from: https://github.com/amazon-archives/serverless-app-examples/blob/master/python/hello-world-python3/lambda_function.py

import json

print('Loading function')


# def lambda_handler(event, context):
#     #print("Received event: " + json.dumps(event, indent=2))
#     print("value1 = " + event['key1'])
#     print("value2 = " + event['key2'])
#     print("value3 = " + event['key3'])
#     return event['key1']  # Echo back the first key value
#     #raise Exception('Something went wrong')

def lambda_handler(event, context):
  return "Hello World"