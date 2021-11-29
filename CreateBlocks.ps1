$BlockIds = @(


  'LargeBlockFrontLight'
  'SmallBlockFrontLight'
  'RotatingLightLarge'
  'RotatingLightSmall'
  'OffsetSpotlight'


);
$Builder = "ReflectorLight"
$Freigeschaltet = "Meilenstein_Lights"

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
