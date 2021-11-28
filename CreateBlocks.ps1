$BlockIds = @(


  'OffroadSuspension3x3'
  'OffroadSuspension5x5'
  'OffroadSuspension1x1'
  'OffroadSmallSuspension3x3'
  'OffroadSmallSuspension5x5'
  'OffroadSmallSuspension1x1'
  'OffroadSuspension3x3mirrored'
  'OffroadSuspension5x5mirrored'
  'OffroadSuspension1x1mirrored'
  'OffroadSmallSuspension3x3mirrored'
  'OffroadSmallSuspension5x5mirrored'
  'OffroadSmallSuspension1x1mirrored'

  


);
$Builder = "MotorSuspension"
$Freigeschaltet = "Meilenstein_Räder"

$TextBlock = '
        <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXX  zzzzz-->
          <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXX" />
          <UnlockedByGroups>
            <GroupSubtype>zzzzz</GroupSubtype>
          </UnlockedByGroups>
        </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Freigeschaltet
Write-Host $temp

}
