- Serverless query service to analyze data stored in Amazon S3
- Uses standard SQL language to query the files (built on Presto)
- Supports CSV, JSON, ORC, Avro, and Parquet
- Pricing: $5.00 per TB of data scanned
- Commonly used with Amazon Quicksight for reporting / dashboards
- Uses cases: Business intelligence / analytics / reporting, analyze & query VPC Flow Logs, ELB Logs, CloudTrail trails, etc...

# Performance Improvement

- Use **columnar data** for cost-savings (less scan)
  - Apache Parquet or ORC is recommended
  - Huge performance improvement
  - Use Glue to convert your data to Parquet or ORC
- Compress data for smaller retrievals (bzip2, gzip, lz4, snappy, zlip, zstd...)
- Partition datasets in S3 for easy querying on virtual columns
  - s3://yourBucket/pathToTable
    - /<PARTITION_COLUMN_NAME>=<VALUE>
      - /<PARTITION_COLUMN_NAME>=<VALUE>
        - /<PARTITION_COLUMN_NAME>=<VALUE>
          - /etc...
  - Example: s3://athena-examples/flight/parquet/year=1991/month=1/day=1/
- Use larger files (> 128 MB) to minimize overhead

# Federated Query

- Allows you to run SQL queries across data stored in relational, non-relational, object, and custom data sources (AWS or on-premises)
- Uses Data Source Connectors that run on AWS Lambda to run Federated Queries (e.g., CloudWatch Logs, DynamoDB, RDS, ...)
- Store the results back in Amazon S3

# Best Practices
- **Partition your data** – Partition the table into parts and keeps the related data together based on column values such as date, country, region, etc. Athena supports Hive partitioning.
- **Bucket your data** – Partition your data is to bucket the data within a single partition.
- **Use Compression** – AWS recommend using either Apache Parquet or Apache ORC.
- **Optimize file sizes** – Queries run more efficiently when reading data can be parallelized and when blocks of data can be read sequentially.
- **Optimize columnar data store generation** – Apache Parquet and Apache ORC are popular columnar data stores.
- **Optimize ORDER BY** – The ORDER BY clause returns the results of a query in sort order.
- **Optimize GROUP BY** – The GROUP BY operator distributes rows based on the GROUP BY columns to worker nodes, which hold the GROUP BY values in memory.
- **Use approximate functions** – For exploring large datasets, a common use case is to find the count of distinct values for a certain column using COUNT(DISTINCT column).
- **Only include the columns that you need** – When running your queries, limit the final SELECT statement to only the columns that you need instead of selecting all columns.