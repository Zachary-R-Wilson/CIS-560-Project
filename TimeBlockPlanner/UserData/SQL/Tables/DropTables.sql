
-- Goal
ALTER TABLE [User].Goal DROP CONSTRAINT FK_User_Goal_User_UserId;
--ALTER TABLE [User].Goal DROP CONSTRAINT UK_User_Goal_UserId_Name_Description;

-- TimeBlock
ALTER TABLE [User].TimeBlock DROP CONSTRAINT FK_User_TimeBlock_User_UserId;

--UserMetric
ALTER TABLE [User].UserMetric DROP CONSTRAINT FK_User_UserMetric_User_UserId;
ALTER TABLE [User].UserMetric DROP CONSTRAINT FK_User_Metric_MetricId;
ALTER TABLE [User].UserMetric DROP CONSTRAINT FK_User_MetricTimeframe_MetricTimeframeId;



DROP TABLE IF EXISTS [User].TimeBlock;	
DROP TABLE IF EXISTS [User].Goals;	
DROP TABLE IF EXISTS [User].UserMetric;	

DROP TABLE IF EXISTS [User].[User];
DROP TABLE IF EXISTS [User].Metric;	
DROP TABLE IF EXISTS [User].MetricTimeframe;


-- might need to change all User.User to UserDate.User, 
-- but going based off of his solution for now

