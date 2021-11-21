$BlockIds = @(
'LargeBlockArmorBlock'
'LargeHeavyBlockArmorSlope'
'LargeBlockArmorRoundSlope'
'LargeBlockArmorRoundSlope'
'LargeBlockArmorRoundSlope'
'LargeBlockArmorRoundSlope'
'LargeBlockArmorRoundSlope'
'RoundArmorSlope'
);
$Builder = "CubeBlocks"
$Gruppe = "Armor"

$TextBlock = '
    <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXXXXX-->
      <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXXXXX" />
      <UnlockedByGroups>
        <GroupSubtype>zzzzz</GroupSubtype>
      </UnlockedByGroups>
    </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Gruppe
Write-Host $temp

}
