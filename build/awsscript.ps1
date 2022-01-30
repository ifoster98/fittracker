/usr/local/bin/aws --endpoint-url=http://localhost:4566 s3 mb s3://fittracker-client
/usr/local/bin/aws s3api --endpoint-url=http://localhost:4566 put-public-access-block `
      --bucket fittracker-client `
      --public-access-block-configuration "BlockPublicAcls=false,IgnorePublicAcls=false,BlockPublicPolicy=false,RestrictPublicBuckets=false"
/usr/local/bin/aws s3 --endpoint-url=http://localhost:4566 website "s3://fittracker-client" --index-document index.html --error-document index.html
/usr/local/bin/aws s3 --endpoint-url=http://localhost:4566 sync /Users/ianfoster/dev/fittracker/website "s3://fittracker-client"

aws --endpoint-url=http://localhost:4566 iam create-role --role-name "aws-fittracker-execution-role" --assume-role-policy-document file://execution-role.json
aws --endpoint-url=http://localhost:4566 iam create-role --role-name "aws-fittracker-trust-role" --assume-role-policy-document file://trust-policy.json
