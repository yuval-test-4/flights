terraform {
  backend "s3" {
    bucket = "terraform-state-demonstration"
    key    = "development/flights"
    region = "us-east-1"
  }
}